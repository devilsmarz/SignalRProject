import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticatedResponse } from 'src/models/authenticatedResponse';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    loginLabel = new FormControl('', [Validators.required]);

  constructor(private router: Router, 
    private http: HttpClient,
    private jwtHelper: JwtHelperService
    ) {}

  public login(){
    this.http.post<AuthenticatedResponse>("https://localhost:5001/api/auth/login", {login: this.loginLabel.value}, {
        headers: new HttpHeaders({ "Content-Type": "application/json"})
      })
      .subscribe({
        next: (response: AuthenticatedResponse) => {
          const token = response.token;
          localStorage.setItem("jwt", token); 
          this.router.navigate(["chat"])
    },
    error: (err: HttpErrorResponse) => alert("Something went wrong")
    });
  }
ngOnInit(): void {
    if(this.isUserAuthenticated())
    {
        this.router.navigate(["chat"])
    };
}
  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("jwt");
  
    if (token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }
  
    return false;
  }
}