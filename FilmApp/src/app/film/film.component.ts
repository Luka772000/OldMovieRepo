import { Component, OnInit ,ViewChild } from '@angular/core';
import { filmService } from '../shared/film.service';
import { ToastrService } from 'ngx-toastr';
import { NgbModalConfig,NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient, HttpParams } from "@angular/common/http";


const APIKEY = "d6b1bc0a";
const PARAMS = new HttpParams({
  fromObject: {
    action: "opensearch",
    format: "json",
    origin: "*"
  }
});
@Component({
  selector: 'app-film',
  templateUrl: './film.component.html',
  

})
export class FilmComponent implements OnInit {
  @ViewChild('movieSearchInput', { static: true })

  page=4
  apiResponse: any;
  movieDetails: any;
  ime:string='';
  isShowDiv: boolean=true;
  isShowElse: boolean=false;

  constructor(config: NgbModalConfig, private modalService: NgbModal,
    public service: filmService,
    private http:HttpClient,
    private toastr:ToastrService) 
    
    {config.backdrop = 'static'; this.movieDetails = []; }

  ngOnInit(): void {
    this.service.refreshlist();
    
  }


onDelete(id:number){
  this.service.deleteFilm(id)
  .subscribe(
    res=>{this.service.refreshlist();
    this.toastr.success("Uspješno izbrisano")},
    err=>{console.log(err)}
  )
}


open(content: any) {
  this.modalService.open(content);
}


getDetails(pd: any){
  
  this.http.get('http://www.omdbapi.com/?t=' + pd.ime + '&apikey=' + APIKEY, { params: PARAMS.set('search', pd.ime) })
  .subscribe(data=> {
 console.log('res', data);
  this.movieDetails=data;
  if(this.movieDetails.Response=="False"){
    this.toastr.error("Film nije pronađen");
  }

  else{
    this.toastr.info("Film je pronađen")
    this.isShowDiv = false;
    this.isShowElse= true;
  }
  
  })
  }


close(){
  this.isShowDiv=true; 
  this.isShowElse=false;
}
  
}
