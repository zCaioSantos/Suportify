import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AppConfigService {
  private appConfig: any;

  constructor(private http: HttpClient) {}

  async loadAppConfig() {
    const appConfigLoad = this.http.get('assets/config.json');
    this.appConfig = await lastValueFrom(appConfigLoad);
  }

  get apiEndpoint() {
    if (!this.appConfig) {
      throw Error('O arquivo de configuração não foi encontrado!');
    }

    return this.appConfig.apiEndpoint;
  }

  get applicationHash() {
    if (!this.appConfig) {
      throw Error('O arquivo de configuração não foi encontrado!');
    }

    return this.appConfig.applicationHash;
  }

  get isLoaded(): boolean {
    return this.appConfig != null;
  }
}
