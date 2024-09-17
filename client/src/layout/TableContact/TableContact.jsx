import React from "react";
import RowTableContact from "./components/RowTableContact"



const TableContact = (props) => {
    return (
        <table className = "table table-hover">
            <thead>
              <tr>
                <th>#</th>
                <th>Name</th>
                <th>Email</th>
              </tr>
            </thead>
            <tbody>
              {
                props.contacts.map(
                      contact => 
                        <RowTableContact
                        key = {contact.id}
                        Id = {contact.id}
                        Name = {contact.name}
                        Email = {contact.email}
                        deleteContact ={props.deleteContact}
                        />  
                )
              }
            </tbody>
          </table>
    )
}
export default TableContact;