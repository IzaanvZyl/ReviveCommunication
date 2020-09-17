import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GoalsServiceService {
  selectedCust: any;
  selectedCust1: any;

  constructor( private http: HttpClient) {}

  setHomecellAttGoal(newGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/SetHomecellAttGoal', newGoal).subscribe(x => {
      console.log(x)
    })
  }

  setChurchAttGoal(newGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/SetChurchAttGoal', newGoal).subscribe(x => {
      console.log(x)
    })
  }

  setZoneHomecellAttGoal(newGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/SetZoneHomecellAttGoal', newGoal).subscribe(x => {
      console.log(x)
    })
  }

  setZoneChurchAttGoal(newGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/SetZoneChurchAttGoal', newGoal).subscribe(x => {
      console.log(x)
    })
  }

  setDiscipleshipGoal(newGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/SetDiscipleshipGoal', newGoal).subscribe(x => {
      console.log(x)
    })
  }

  setNMOGoal(newGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/SetNMOGoal', newGoal).subscribe(x => {
      console.log(x)
    })
  }

  setStructureGrowthGoal(newGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/SetStructureGrowthGoal', newGoal).subscribe(x => {
      console.log(x)
    })
  }

  setZoneGrowthGoal(newGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/SetZoneGrowthGoal', newGoal).subscribe(x => {
      console.log(x)
    })
  }

//Delete Goals
  deleteHomecellAttGoal(goal)
  {
    console.log(goal);
    this.http.post('https://localhost:44390/api/Goals/RemoveHomecellAttGoal', goal).subscribe(x => {
      console.log(x)
    })
  }

  deleteChurchAttGoal(goal)
  {
    console.log(goal);

    
    this.http.delete('https://localhost:44349/api/Customers/DeleteCustomersWithOrders', goal).subscribe(x => {
      console.log(x)
    })
  }

  deleteZoneHomecellAttGoal(goal)
  {
    console.log(goal);

     
    this.http.delete('https://localhost:44349/api/Customers/DeleteCustomersWithOrders', goal).subscribe(x => {
      console.log(x)
    })
  }

  deleteZoneChurchAttGoal(goal)
  {
    console.log(goal);

        this.http.delete('https://localhost:44349/api/Customers/DeleteCustomersWithOrders', goal).subscribe(x => {
      console.log(x)
    })
  }

  deleteNMOGoal(goal)
  {
    console.log(goal);

      
    this.http.delete('https://localhost:44349/api/Customers/DeleteCustomersWithOrders', goal).subscribe(x => {
      console.log(x)
    })
  }

  deleteDiscipleshipGoal(goal)
  {
    console.log(goal);
    
    this.http.delete('https://localhost:44349/api/Customers/DeleteCustomersWithOrders', goal).subscribe(x => {
      console.log(x)
    })
  }

  deleteStructureGrowthGoal(goal)
  {
    console.log(goal);
  
    this.http.delete('https://localhost:44349/api/Customers/DeleteCustomersWithOrders', goal).subscribe(x => {
      console.log(x)
    })
  }

  deleteZoneGrowthGoal(goal)
  {
    console.log(goal);
    
    this.http.delete('https://localhost:44349/api/Customers/DeleteCustomersWithOrders', goal).subscribe(x => {
      console.log(x)
    })
  }


  setData(cust)
  {
    console.log(cust);
    this.selectedCust = cust;
  }

  getData()
  {
    console.log(this.selectedCust);
     return this.selectedCust;
  }

  setData1(cust)
  {
    console.log(cust);
    this.selectedCust1 = cust;
  }

  getData1()
  {
    console.log(this.selectedCust1);
     return this.selectedCust1;
  }

  //Get goal data 
  getHomecellAtt(){
    return this.http.get('https://localhost:44390/api/Goals/getAllHomecellAttGoal');
  }

  getChurchAtt(){
    return this.http.get('https://localhost:44390/api/Goals/getAllHomecellAttGoal');
  }

  getZoneHomecellAtt(){
    return this.http.get('https://localhost:44390/api/Goals/getAllHomecellAttGoal');
  }

  getZoneChurchAtt(){
    return this.http.get('https://localhost:44390/api/Goals/getAllHomecellAttGoal');
  }

  getNMO(){
    return this.http.get('https://localhost:44390/api/Goals/getAllHomecellAttGoal');
  }

  getDiscipleship(){
    return this.http.get('https://localhost:44390/api/Goals/getAllHomecellAttGoal');
  }
  
  getStructureGrwoth(){
    return this.http.get('https://localhost:44390/api/Goals/getAllHomecellAttGoal');
  }

  getZoneGrowth(){
    return this.http.get('https://localhost:44390/api/Goals/getAllHomecellAttGoal');
  }

  //update goal
  updateHomecellAttGoal(updatedGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/UpdateHomecellAttGoal', updatedGoal).subscribe(x => {
      console.log(x)
    })
  }

  updateChurchAttGoal(updatedGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/updateChurchAttGoal', updatedGoal).subscribe(x => {
      console.log(x)
    })
  }

  updateZoneHomecellAttGoal(updatedGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/updateZoneHomecellAttGoal', updatedGoal).subscribe(x => {
      console.log(x)
    })
  }

  updateZoneChurchAttGoal(updatedGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/updateZoneChurchAttGoal', updatedGoal).subscribe(x => {
      console.log(x)
    })
  }

  updateDiscipleshipGoal(updatedGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/updateDiscipleshipGoal', updatedGoal).subscribe(x => {
      console.log(x)
    })
  }

  updateNMOGoal(updatedGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/updateNMOGoal', updatedGoal).subscribe(x => {
      console.log(x)
    })
  }

  updateStructureGrowthGoal(updatedGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/updateStructureGrowthGoal', updatedGoal).subscribe(x => {
      console.log(x)
    })
  }

  updateZoneGrowthGoal(updatedGoal)
  {
    this.http.post('https://localhost:44390/api/Goals/updateZoneGrowthGoal', updatedGoal).subscribe(x => {
      console.log(x)
    })
  }
  

  getHomecellAttFeedback(){
    return this.http.get('https://localhost:44390/api/Feedback/getAllHomecellAttFeedback');
  }
  getZoneHomecellAttFeedback(){
    return this.http.get('https://localhost:44390/api/Feedback/getAllZoneHomecellAttFeedback');
  }
  getChurchAttFeedback(){
    return this.http.get('https://localhost:44390/api/Feedback/getAllChurchAttFeedback');
  }
}


