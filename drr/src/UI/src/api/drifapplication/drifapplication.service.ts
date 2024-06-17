/**
 * Generated by orval v6.27.1 🍺
 * Do not edit manually.
 * DRR API
 * OpenAPI spec version: 1.0.0
 */
import {
  HttpClient
} from '@angular/common/http'
import type {
  HttpContext,
  HttpHeaders,
  HttpParams
} from '@angular/common/http'
import {
  Injectable
} from '@angular/core'
import {
  Observable
} from 'rxjs'
import type {
  ApplicationResult,
  DeclarationResult,
  DrifDrafEoiApplication,
  DrifEoiApplication
} from '../../model'


type HttpClientOptions = {
  headers?: HttpHeaders | {
      [header: string]: string | string[];
  };
  context?: HttpContext;
  observe?: any;
  params?: HttpParams | {
    [param: string]: string | number | boolean | ReadonlyArray<string | number | boolean>;
  };
  reportProgress?: boolean;
  responseType?: any;
  withCredentials?: boolean;
};



@Injectable({ providedIn: 'root' })
export class DrifapplicationService {
  constructor(
    private http: HttpClient,
  ) {} dRIFApplicationGet<TData = DrifEoiApplication[]>(
     options?: HttpClientOptions
  ): Observable<TData>  {
    return this.http.get<TData>(
      `/api/drifapplication`,options
    );
  }
 dRIFApplicationGetDeclarations<TData = DeclarationResult>(
     options?: HttpClientOptions
  ): Observable<TData>  {
    return this.http.get<TData>(
      `/api/drifapplication/declarations`,options
    );
  }
 dRIFApplicationCreateEOIApplication<TData = ApplicationResult>(
    drifEoiApplication: DrifEoiApplication, options?: HttpClientOptions
  ): Observable<TData>  {
    return this.http.post<TData>(
      `/api/drifapplication/eoi`,
      drifEoiApplication,options
    );
  }
 dRIFApplicationCreateDraftEOIApplication<TData = ApplicationResult>(
    drifDrafEoiApplication: DrifDrafEoiApplication, options?: HttpClientOptions
  ): Observable<TData>  {
    return this.http.post<TData>(
      `/api/drifapplication/eoi/draft`,
      drifDrafEoiApplication,options
    );
  }
};

export type DRIFApplicationGetClientResult = NonNullable<DrifEoiApplication[]>
export type DRIFApplicationGetDeclarationsClientResult = NonNullable<DeclarationResult>
export type DRIFApplicationCreateEOIApplicationClientResult = NonNullable<ApplicationResult>
export type DRIFApplicationCreateDraftEOIApplicationClientResult = NonNullable<ApplicationResult>
