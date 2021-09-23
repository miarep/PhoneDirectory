import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { TreeViewModule } from '@progress/kendo-angular-treeview';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, TreeViewModule, BrowserAnimationsModule],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }