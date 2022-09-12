import { HttpHeaders, HttpErrorResponse, HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticatedResponse } from 'src/models/authenticatedResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService  {

  constructor(private router: Router, 
    private http: HttpClient,
    private jwtHelper: JwtHelperService
    ) {}

  public login(userName: string){
    this.http.post<AuthenticatedResponse>("auth/login", {userName: userName}, {
        headers: new HttpHeaders({ "Content-Type": "application/json"})
      })
      .subscribe({
        next: (response: AuthenticatedResponse) => {
          localStorage.setItem("jwt", response.token); 
          localStorage.setItem("userId", response.userId.toString());
          localStorage.setItem("userName", response.userName);  
          this.router.navigate(["chat"])
    },
    error: (err: HttpErrorResponse) => alert("Something went wrong")
    });
  }

  logout(){
    localStorage.clear();
    this.router.navigate([""]);
  }

  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("jwt");
  
    if (token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }
  
    return false;
  }
}
