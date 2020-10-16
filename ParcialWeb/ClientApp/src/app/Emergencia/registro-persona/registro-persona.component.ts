import { Component, OnInit } from '@angular/core';
import { persona } from './../models/persona';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonaService } from './../../services/persona.service';

@Component({
  selector: 'app-registro-persona',
  templateUrl: './registro-persona.component.html',
  styleUrls: ['./registro-persona.component.css']
})
export class RegistroPersonaComponent implements OnInit {
  persona: persona;
  formGroup: FormGroup;

  constructor(private personaService: PersonaService, private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {

    this.buildForm();
  }

  private buildForm() {
    this.persona = new persona();
    this.persona.identificacion = '';
    this.persona.nombre = '';
    this.persona.apellidos = '';
    this.persona.ciudad = '';
    this.persona.departamento = '';
    this.persona.edad = 0;
    this.persona.fecha = '';
    this.persona.modalidadApoyo = '';
    this.persona.sexo = '';
    this.persona.valorApoyo = 0;
    this.formGroup = this.formBuilder.group({
      identificacion: [this.persona.identificacion, Validators.required],
      nombre: [this.persona.nombre, Validators.required],
      apellidos: [this.persona.apellidos, Validators.required],
      ciudad: [this.persona.ciudad, Validators.required],
      departamento: [this.persona.departamento, Validators.required],
      edad: [this.persona.edad, Validators.required],
      fecha: [this.persona.fecha, Validators.required],
      modalidadApoyo: [this.persona.modalidadApoyo, Validators.required],
      valorApoyo: [this.persona.valorApoyo, [Validators.required, Validators.min(1)]],
      sexo: [this.persona.sexo, [Validators.required]]
    });
  }

  get control() {
    return this.formGroup.controls;
  }
  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.agregar();
  }
  agregar() {
    this.persona = this.formGroup.value;
    this.personaService.post(this.persona).subscribe(p => {
      if (p != null) {
        alert("Se ha guardado. ");
      }
    })
  }

}
