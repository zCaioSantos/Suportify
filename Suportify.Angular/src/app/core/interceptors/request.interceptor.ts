import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfigService } from '../services/app-config.service';

@Injectable({
  providedIn: 'root',
})
export class RequestInterceptor implements HttpInterceptor {
  // private authService = inject(AuthenticationService);
  private appConfigService = inject(AppConfigService);

  // constructor(private authenticationService: AuthenticationService) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (request.url.includes('/usuario')) {
      return next.handle(request);
    }

    if (this.appConfigService.isLoaded) {
      // const sessionInfo = this.authService.getCurrentUser();
      // if (sessionInfo) {
      //   request = request.clone({
      //     setHeaders: {
      //       usuarioId: sessionInfo?.certthumbprint!,
      //       perfil: sessionInfo?.role!,
      //     },
      //   });
      // }
    }

    return next.handle(request);
  }
}
