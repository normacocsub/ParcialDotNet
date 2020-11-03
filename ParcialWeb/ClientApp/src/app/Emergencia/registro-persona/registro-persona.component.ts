import { Component, OnInit } from '@angular/core';
import { persona } from './../models/persona';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonaService } from './../../services/persona.service';
import { Ayudas } from '../models/ayudas';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../../@base/modal/modal.component';

@Component({
  selector: 'app-registro-persona',
  templateUrl: './registro-persona.component.html',
  styleUrls: ['./registro-persona.component.css']
})
export class RegistroPersonaComponent implements OnInit {
  persona: persona;
  ayuda: Ayudas;
  formGroup: FormGroup;
  formGroup2: FormGroup;
  validateForm1: boolean = false;
  validateForm2: boolean;

  constructor(private personaService: PersonaService, private formBuilder: FormBuilder, private modalService: NgbModal) {
  }

  ngOnInit(): void {

    this.buildForm();
    this.buildForm2();
  }

  private buildForm2() {
    this.ayuda = new Ayudas();
    this.ayuda.fecha = '';
    this.ayuda.modalidadApoyo = '';
    this.ayuda.valorApoyo = 0;

    this.formGroup2 = this.formBuilder.group({
      fecha: [this.ayuda.fecha, Validators.required],
      modalidadApoyo: [this.ayuda.modalidadApoyo, Validators.required],
      valorApoyo: [this.ayuda.valorApoyo, [Validators.required, Validators.min(1)]]
    });
  }
  private buildForm() {
    this.persona = new persona();
    this.persona.identificacion = '';
    this.persona.nombre = '';
    this.persona.apellidos = '';
    this.persona.ciudad = '';
    this.persona.departamento = '';
    this.persona.edad = 0;
    
    this.persona.sexo = '';

    this.formGroup = this.formBuilder.group({
      identificacion: [this.persona.identificacion, Validators.required],
      nombre: [this.persona.nombre, Validators.required],
      apellidos: [this.persona.apellidos, Validators.required],
      ciudad: [this.persona.ciudad, Validators.required],
      departamento: [this.persona.departamento, Validators.required],
      edad: [this.persona.edad, Validators.required],
      sexo: [this.persona.sexo, [Validators.required]]
    });
  }

  get control() {
    return this.formGroup.controls;
  }

  get control2() {
    return this.formGroup2.controls;
  }
  onSubmit() {
    if (this.formGroup.invalid && this.formGroup2.invalid) {
      this.validateForm1 = false;
      return this.validateForm1;
    }
    this.agregar();
  }

  validar(){
    if (this.formGroup.invalid || this.formGroup2.invalid) {
      this.validateForm1 = false;
      return this.validateForm1;
    }
    else
    {
      return true;
    }
  }
  
  agregar() {
    this.persona = this.formGroup.value;
    this.ayuda = this.formGroup2.value;
    this.persona.ayudas = this.ayuda;
    this.personaService.post(this.persona).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(ModalComponent)​
        messageBox.componentInstance.title = "Resultado Operación";​
        messageBox.componentInstance.cuerpo = 'Persona creada!!! :-)';
        this.persona = p;
      }
    })
  }

}
