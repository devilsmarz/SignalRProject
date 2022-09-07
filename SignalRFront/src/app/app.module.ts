import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BaseUrlInterceptor } from '../shared/interceptors/baseurl-interceptor-service';
import { SharedModule } from './shared.module';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { ChatComponent } from './chat-portal/chat.component';

 const appRoutes: Routes =[
   {path: '', component: LoginComponent},
   {path: 'chat', component: ChatComponent}
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
  ],
  providers: [
    HttpClientModule,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: BaseUrlInterceptor,
      multi: true,
    },
 ],
  bootstrap: [AppComponent]
})
export class AppModule { }
