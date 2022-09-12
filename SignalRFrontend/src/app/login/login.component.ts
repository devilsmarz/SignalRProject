import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthorizationService } from 'src/services/authorization-service/authorization-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    loginLabel = new FormControl('', [Validators.required]);

  constructor(private router: Router, 
    private authorizationService: AuthorizationService
    ) {}

  public login(){
    this.authorizationService.login(this.loginLabel.value ?? "")
  }
  ngOnInit(): void {
    if(this.authorizationService.isUserAuthenticated())
    {
        this.router.navigate(["chat"])
    };
}
}
