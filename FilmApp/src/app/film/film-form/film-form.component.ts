import { Component, OnInit , Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Film } from 'src/app/shared/film.model';
import { filmService } from 'src/app/shared/film.service';
import { NgbModalConfig,NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FilmComponent } from '../film.component';




@Component({
  selector: 'app-film-form',
  templateUrl: './film-form.component.html',
  styles: [
  ]
})
export class FilmFormComponent implements OnInit {
  constructor(config: NgbModalConfig, private modalService: NgbModal,public service:filmService,
    private toastr:ToastrService) { config.backdrop = 'static';
    config.keyboard = false;
    
    
  }
  value = 'Izbriši me'
  
  ngOnInit(): void {
  }
  onSubmit(form:NgForm){
    this.insertRecord(form);
    
  }
  insertRecord(form:NgForm){
    this.service.putFilm().subscribe(
      res=>{
this.resetForm(form);
this.service.refreshlist();

      },
      err=>{console.log(err);})
  }
  updateRecord(form: NgForm) {
    this.service.putFilm().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshlist();
        this.toastr.info('Updated successfully', 'Film updejtovan')
      },
      err => { console.log(err); }
    );
  }

resetForm(form:NgForm){ 
  form.reset()
  this.service.formData=new Film();
}
open(content: any) {
  this.modalService.open(content);
  
}
}
