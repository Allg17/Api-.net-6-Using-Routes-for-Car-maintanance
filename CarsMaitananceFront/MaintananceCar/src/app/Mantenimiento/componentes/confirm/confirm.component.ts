import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Confirm } from '../../../Interfaces/Confirm';

@Component({
  selector: 'app-confirm',
  templateUrl: './confirm.component.html',
  styleUrls: ['./confirm.component.css']
})
export class ConfirmComponent {
  constructor(private dialref: MatDialogRef<ConfirmComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Confirm) { }

  ngOnInit(): void {
  }

  continuar() {
    this.dialref.close(true);
  }

  cancelar() { this.dialref.close(); }
}
