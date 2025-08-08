import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Button } from 'primeng/button';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  imports: [CommonModule, Button],
})
export class HomeComponent {}
