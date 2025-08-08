import { inject, Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { AppConfigService } from '../services/app-config.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  private router = inject(Router);
  private appConfigService = inject(AppConfigService);

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (
      sessionStorage.getItem(`user-${this.appConfigService.applicationHash}`)
    ) {
      return true;
    }

    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
