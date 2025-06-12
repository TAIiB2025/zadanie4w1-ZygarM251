import { Component, inject } from '@angular/core';
import { ListaService } from '../lista.service';
import { Observable } from 'rxjs';
import { Ksiazka } from '../../models/ksiazka';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-lista',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './lista.component.html',
  styleUrl: './lista.component.css'
})
export class ListaComponent {
  private readonly listaService = inject(ListaService);

  public dane: Ksiazka[] = [];
  public fraza: string = '';

  constructor() {
    this.listaService.get().subscribe(d => this.dane = d);
  }
  
  filtruj() {
    this.listaService.get(this.fraza).subscribe(d => this.dane = d);
  }
}
