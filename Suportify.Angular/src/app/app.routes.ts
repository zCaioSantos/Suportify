import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: '/aplicacao/home',
    pathMatch: 'full',
  },
  {
    path: 'login',
    data: { breadcrumb: 'login' },
    loadComponent: () =>
      import('./pages/public/login/login.component').then(
        (m) => m.LoginComponent
      ),
  },
  {
    path: 'aplicacao',
    children: [
      {
        path: 'home',
        data: { breadcrumb: 'Home' },
        loadComponent: () =>
          import('./pages/private/home/home.component').then(
            (m) => m.HomeComponent
          ),
      },
    ],
  },
];
