import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
    loginLabel = new FormControl('', [Validators.required]);

  constructor(private router: Router, private http: HttpClient) {}

  public login(){
    this.http.get(`login/${this.loginLabel.value}`)
    .subscribe(response =>{
        const token = (<any>response).token;
        localStorage.setItem("token", token);
        this.router.navigate(["chat"])
    }, error => {
       console.log(error);
    });
  }
}