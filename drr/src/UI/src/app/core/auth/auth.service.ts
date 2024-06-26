import { isPlatformBrowser } from '@angular/common';
import { Injectable, PLATFORM_ID, inject } from '@angular/core';
import { AuthConfig, OAuthEvent, OAuthService } from 'angular-oauth2-oidc';
import { ProfileService } from '../../../api/profile/profile.service';
import { ConfigurationStore } from '../../store/configuration.store';
import { ProfileStore } from '../../store/profile.store';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  oauthService = inject(OAuthService);
  profileStore = inject(ProfileStore);
  configurationStore = inject(ConfigurationStore);
  profileService = inject(ProfileService);
  platformId = inject(PLATFORM_ID);

  async setProfile() {
    if (this.isLoggedIn()) {
      const profile = this.getProfile();
      // const profileDetails = await firstValueFrom(
      //   this.profileService.profileProfileDetails()
      // );

      this.profileStore.setProfile({
        fullName: profile['name'],
        // firstName: profileDetails.firstName,
        // lastName: profileDetails.lastName,
        // title: profileDetails.title,
        // department: profileDetails.department,
        // phone: profileDetails.phone,
        // email: profile['email'],
        organization: profile['bceid_business_name'],
        loggedIn: true,
      });

      return true;
    }

    return false;
  }

  async login() {
    if (!isPlatformBrowser(this.platformId)) {
      // this means we are on the server side and window object is not available
      // this will run again on the client side
      return false;
    }

    const authConfig: AuthConfig = {
      responseType: 'code',
      strictDiscoveryDocumentValidation: false,
      showDebugInformation: false,
      requireHttps: true,
      redirectUri: window.location.origin + '/dashboard',
      openUri: (uri: string) => {
        const url = new URL(uri);

        // url.searchParams.delete('id_token_hint');
        // reconstruct url
        const reconstructUri = `${url.origin}${
          url.pathname
        }?${url.searchParams.toString()}`;

        location.href = reconstructUri;
      },
      postLogoutRedirectUri: window.location.origin, // TODO: maybe it supposed to be landing page?
    };

    if (!this.configurationStore.isConfigurationLoaded()) {
      console.error('Configuration is not loaded yet');
      return false;
    }

    const configuration = this.configurationStore.oidc!();

    this.oauthService.configure({
      ...authConfig,
      ...configuration,
    });

    this.oauthService.timeoutFactor = 0.7;

    this.oauthService.setupAutomaticSilentRefresh();

    this.oauthService.events.subscribe({
      next: (event: OAuthEvent) => {
        console.log('event', event);
      },
    });

    try {
      const isLoggedIn =
        await this.oauthService.loadDiscoveryDocumentAndLogin();

      if (this.isLoggedIn() && isLoggedIn) {
        this.setProfile();
        return true;
      } else {
        // Pass in the original URL as additional state to the identity provider.  This information will be
        // returned once the user has been authenticated and will be used to redirect the user to the
        // originally requested URL.
        // DO NOT URL encode the state value as that happens automatically by the OAuthService.  Just convert
        // to base64.
        const encodedState = btoa(
          JSON.stringify({ originalURL: window.location.href })
        );

        this.oauthService.initCodeFlow(encodedState);
        return false;
      }
    } catch (error) {
      return Promise.resolve(false);
    }
  }

  getProfile() {
    // get data from jwt token
    return this.oauthService.getIdentityClaims();
  }

  isLoggedIn() {
    return (
      this.oauthService.hasValidAccessToken() &&
      this.oauthService.hasValidIdToken()
    );
  }

  logout() {
    this.oauthService.logOut();
  }
}
