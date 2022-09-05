import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(public http: HttpClient) {
  }

  ngOnInit(): void {

  }

  public get()
  {
    this.http.delete('api/Values/5');
  }
}