import { Pipe, PipeTransform } from '@angular/core';
import { persona } from '../Emergencia/models/persona';

@Pipe({
  name: 'filtroPersona'
})
export class FiltroPersonaPipe implements PipeTransform {

  personas2: persona[];
  transform(personas: persona[], searchText: string): any {

    if (searchText == null || searchText == "Seleccionar") return personas;
    if (searchText == "alimentario" || searchText == "económico")
    {
      return personas.filter(p=>p.ayudas.modalidadApoyo.toLowerCase().indexOf(searchText)!== -1);
    }
    return  personas.filter(p => p.nombre.toLowerCase()​.indexOf(searchText.toLowerCase()) !== -1) ||
    personas.filter(p=>p.ayudas.modalidadApoyo.toLowerCase().indexOf(searchText.toLowerCase()) !== -1);

    


  }

}
