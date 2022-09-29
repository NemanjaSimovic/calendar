import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './pages/about/about.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { CreateTaskComponent } from './pages/create-task/create-task.component';
import { GlobalCalendarComponent } from './pages/global-calendar/global-calendar.component';
import { HomeComponent } from './pages/home/home.component';
import { UserCalendarComponent } from './pages/user-calendar/user-calendar.component';

const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "about", component: AboutComponent},
  {path: "calendar/global", component: GlobalCalendarComponent},
  {path: "calendar/user", component: UserCalendarComponent},
  {path: "auth/register", component: RegisterComponent},
  {path: "auth/login", component: LoginComponent},
  {path: "create/task", component: CreateTaskComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
