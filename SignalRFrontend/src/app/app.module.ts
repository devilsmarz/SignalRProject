import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BaseUrlInterceptor } from '../services/interceptors/baseurl-interceptor-service';
import { SharedModule } from './shared.module';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { ChatComponent } from './chat-portal/chat.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from 'src/services/authGuard/authGuard';
import { tokenGetter } from './shared/functions';
import { DatePipe } from '@angular/common';

 const appRoutes: Routes =[
   {path: '', component: LoginComponent},
   {path: 'chat', component: ChatComponent, canActivate: [AuthGuard]},
   {path: '**', component: LoginComponent }
 ]

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ChatComponent,
  ],
  imports: [
    BrowserModule, 
    HttpClientModule,
    BrowserAnimationsModule, 
    SharedModule, 
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5001"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [
    HttpClientModule,
    AuthGuard,
    DatePipe,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: BaseUrlInterceptor,
      multi: true,
    },
 ],
  bootstrap: [AppComponent]
})
export class AppModule { }
