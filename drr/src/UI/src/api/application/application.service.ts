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
  EOIApplication
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
export class ApplicationService {
  constructor(
    private http: HttpClient,
  ) {} applicationCreateEOIApplication<TData = ApplicationResult>(
    eOIApplication: EOIApplication, options?: HttpClientOptions
  ): Observable<TData>  {
    return this.http.post<TData>(
      `/api/application`,
      eOIApplication,options
    );
  }
};

export type ApplicationCreateEOIApplicationClientResult = NonNullable<ApplicationResult>
