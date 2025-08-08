import { inject, Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { AppConfigService } from '../services/app-config.service';

@Injectable({ providedIn: 'root' })
export class RoleGuard implements CanActivate {
  private router = inject(Router);
  private appConfigService = inject(AppConfigService);
  // private authService = inject(AuthenticationService);

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    // Check if user is logged in
    if (
      !sessionStorage.getItem(`user-${this.appConfigService.applicationHash}`)
    ) {
      this.router.navigate(['/login'], {
        queryParams: { returnUrl: state.url },
      });
      return false;
    }

    // Get current user information
    // const sessionInfo = this.authService.getCurrentUser();

    // Check if user has either 'gestor' or 'admin' role
    const requiredRoles = ['gestor', 'admin'];
    // if (
    //   sessionInfo &&
    //   sessionInfo.role &&
    //   requiredRoles.includes(sessionInfo.role)
    // ) {
    //   return true;
    // }

    // User doesn't have required roles
    this.router.navigate(['/aplicacao', 'home']); // Or another appropriate route
    return false;
  }
}
