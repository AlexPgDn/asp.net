import TableContact from "./layout/TableContact/TableContact";
import React,{useState,useEffect} from "react";
import FormContact from "./layout/Formcontact/FormContact";
import axios from 'axios';
const baseApiUrl = process.env.REACT_APP_API_URL;

const App = () => {
  const [contacts,setContacts] = useState([]);

  useEffect(()=>{
    axios.get(`${baseApiUrl}/contacts`).then(
      res => setContacts(res.data)
    );},[])

  const addContact = (contactName,contactEmail) => {
    const item = 
      { name: contactName, 
        email: contactEmail};

        axios.post(`${baseApiUrl}/contacts`,item).then(
          response => setContacts([...contacts,response.data])
        );}
  
        const deleteContact = (id) => {
    axios.delete(`${baseApiUrl}/contacts/${id}`)
    setContacts(contacts.filter(item => item.id !== id));
  }

  return (
    <div className = "container mt-5">
      <div className ="card" >
        <div className = "card-header">
          <h1>Number of contacts</h1>
        </div>

        <div className = "card-body"> 
          <TableContact 
          contacts = {contacts}
          deleteContact = {deleteContact}
          />
          <FormContact addContact = {addContact}/>
        </div>
      </div>
    </div>
  );
}

export default App;