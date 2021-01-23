import { Component, Inject, NgModule, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-input-data',
  templateUrl: './input-data.component.html'
})

export class InputDataComponent implements OnInit {
  public forecasts: WeatherForecast;
  formulario: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder) {

  }

  ngOnInit() {

    this.formulario = this.formBuilder.group({
      date: null,
      temperatureC: null,
      temperatureF: null,
      summary: null
    });

  }

  public saveData() {
    let JSONForm = JSON.stringify(this.formulario.value);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json');

    console.log(JSONForm);
    this.http.post(this.baseUrl + 'weatherforecast', JSONForm, { headers: header, responseType: 'text' }).subscribe(data => {      
      console.log(data);
    })
  }

}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
