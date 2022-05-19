import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { GlumciService } from '../shared/glumci.service';
@Component({
  selector: 'app-glumci',
  templateUrl: './glumci.component.html',
  styleUrls: ['./glumci.component.css']
})
export class GlumciComponent implements OnInit {

  constructor(public service: GlumciService,
    private http:HttpClient,) { }

  ngOnInit(): void {
    this.service.refreshlist();
    
  }

}
