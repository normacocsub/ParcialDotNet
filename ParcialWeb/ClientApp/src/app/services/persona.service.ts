import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { persona } from '../emergencia/models/persona';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handdleErrorService: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  post(persona: persona): Observable<persona> {
    return this.http.post<persona>(this.baseUrl + 'api/Persona', persona).pipe(
      tap(_ => this.handdleErrorService.log('datos enviados')),
      catchError(this.handdleErrorService.handleError<persona>('Registrar Persona', null))
    );
  }

  get(): Observable<persona[]> {
    return this.http.get<persona[]>(this.baseUrl + 'api/Persona').pipe(
      tap(_ => this.handdleErrorService.log('Datos')),
      catchError(this.handdleErrorService.handleError<persona[]>('Consulta Persona', null))
    );
  }

  TotalAyudas(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'Api/PersonasTotalAyudas').pipe(
      tap(_ => this.handdleErrorService.log('Datos')),
      catchError(this.handdleErrorService.handleError<number>('Consulta Persona', null))
    );
  }


  AyudasTotales(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'Api/PersonaAyudasTotales').pipe(
      tap(_ => this.handdleErrorService.log('Datos')),
      catchError(this.handdleErrorService.handleError<number>('Consulta Persona', null))
    );
  }


}