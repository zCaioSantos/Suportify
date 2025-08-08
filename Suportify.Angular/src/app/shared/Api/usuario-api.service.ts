import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { AppConfigService } from '../../core/services/app-config.service';
import { UsuarioDto } from '../Interfaces/usuario.interface';

@Injectable({ providedIn: 'root' })
export class UsuarioApiService {
  private readonly httpClient = inject(HttpClient);
  private readonly appConfigService = inject(AppConfigService);

  get(id: string): Observable<UsuarioDto> {
    return this.httpClient
      .get<UsuarioDto>(
        `${this.appConfigService.apiEndpoint}/usuarios/get/${id}`
      )
      .pipe((x) => x, catchError(this.handleError));
  }

  create(usuario: UsuarioDto): Observable<UsuarioDto> {
    return this.httpClient
      .post(`${this.appConfigService.apiEndpoint}/usuario/create`, usuario)
      .pipe((x) => x, catchError(this.handleError));
  }

  getAll(): Observable<UsuarioDto[]> {
    return this.httpClient
      .get<UsuarioDto[]>(
        `${this.appConfigService.apiEndpoint}/usuarios/getAll/`
      )
      .pipe((x) => x, catchError(this.handleError));
  }

  update(usuario: UsuarioDto): Observable<UsuarioDto> {
    return this.httpClient
      .post<UsuarioDto>(
        `${this.appConfigService.apiEndpoint}/usarios/update`,
        usuario
      )
      .pipe((x) => x, catchError(this.handleError));
  }

  delete(id: UsuarioDto): Observable<void> {
    return this.httpClient
      .post(`${this.appConfigService.apiEndpoint}/usuarios/delete`, { Id: id })
      .pipe((x) => x, catchError(this.handleError));
  }

  // #region Private Metedos

  private handleError(error: any): Observable<any> {
    console.error('OCORREU UM ERRO AO PROCESSAR A SOLICITAÇÃO', error);
    return throwError(() => error);
  }

  // #endregion
}
