import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-form-register',
  templateUrl: './form-register.component.html',
  styleUrls: ['./form-register.component.css']
})

export class FormRegisterComponent implements OnInit {

  reg = {

    idRegistrado: null,
    identificacion: null,
    nombres: null,
    apellidos: null,
    NombreCompletos: null

  }

  registrados = [
    {idRegistrado:2,identificacion:'0919172551001',nombres:'CUVIC',apellidos:'S.A.S',nombresCompletos:'CUVIC S.A.S'},
    {idRegistrado:4,identificacion:'0919172551',nombres:'Victor',apellidos:'Portugal',nombresCompletos:'Victor Portugal'},
    {idRegistrado:4,identificacion:'0924258130',nombres:'Marla',apellidos:'Arellano',nombresCompletos:'Marla Arellano'}
    
  ];


  constructor() { }

  ngOnInit(): void {
  }

  VerificaRegistros()
  {

  }

  Seleccionar()
  {
    
  }

  Registrar()
  {
    
  }

}
