import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { MessageService } from 'primeng/api';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  protected messageService = inject(MessageService);
  private router = inject(Router);
  // private authService = inject(AuthenticationService);

  constructor() {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((err) => {
        switch (err.status) {
          case 401: // Não autorizado
            // this.authService.logout();
            this.router.navigate(['/login']);
            this.messageService.add({
              severity: 'error',
              summary: 'Erro',
              detail: 'Sua sessão expirou. Por favor, faça login novamente.',
            });
            break;

          case 403: // Proibido
            this.messageService.add({
              severity: 'error',
              summary: 'Erro',
              detail: 'Você não tem permissão para acessar este recurso.',
            });
            break;

          case 404: // Não encontrado
            this.messageService.add({
              severity: 'error',
              summary: 'Erro',
              detail: 'Recurso não encontrado.',
            });
            break;

          case 500: // Erro do servidor
            this.messageService.add({
              severity: 'error',
              summary: 'Erro',
              detail: 'Erro interno do servidor. Tente novamente mais tarde.',
            });
            break;

          case 0: // Erro de conexão
            this.messageService.add({
              severity: 'error',
              summary: 'Erro',
              detail:
                'Não foi possível conectar ao servidor. Verifique sua conexão.',
            });
            break;

          default:
            if (err?.error?.message) {
              this.messageService.add({
                severity: 'error',
                summary: 'Erro',
                detail: err.error.message,
              });
            } else {
              this.messageService.add({
                severity: 'error',
                summary: 'Erro',
                detail: 'Você não tem permissão para acessar este recurso.',
              });
            }
        }

        return throwError(() => err);
      })
    );
  }
}
