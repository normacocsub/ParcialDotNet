import { Component, OnInit } from '@angular/core';
import { persona } from './../models/persona';
import { PersonaService } from './../../services/persona.service';

@Component({
  selector: 'app-consulta-persona',
  templateUrl: './consulta-persona.component.html',
  styleUrls: ['./consulta-persona.component.css']
})
export class ConsultaPersonaComponent implements OnInit {

  personas: persona[];
  total: string;
  numeroAyudas: string;
  
  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
    this.get();
    this.valortotalayudas();
    this.totalayudas();
  }

  get(){
    this.personaService.get().subscribe(result => {
      this.personas = result;
    })
  }

  totalayudas(){
    this.personaService.AyudasTotales().subscribe(result => {
      this.numeroAyudas = result.toString();
    })
    
  }

  valortotalayudas(){
    this.personaService.TotalAyudas().subscribe(result => {
      this.total = result.toString();
    });
  }
}
