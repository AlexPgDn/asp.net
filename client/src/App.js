import TableContact from "./layout/TableContact/TableContact";
import React,{useState} from "react";
import FormContact from "./layout/Formcontact/FormContact";
import axios from 'axios';
const baseApiUrl = process.env.REACT_APP_API_URL;

const App = () => {
  const url = `${baseApiUrl}/contacts`
  console.log(url);
  axios
  .get(url)
  .then(
    res => console.log(res.data)
  ) 
  const [contacts,setContacts] = useState(
    [

      {id: 1, name: "Name", email: "@gmail.com"},
      {id: 2, name: "Name", email: "@gmail.com"},
      {id: 3, name: "Name", email: "@gmail.com"},
      {id: 44, name: "Name", email: "@gmail.com"},
    ]
  );

  const addContact = (contactName,contactEmail) => {
    const maxId = contacts.length === 0 ? 0 : Math.max(...contacts.map(x => x.id));
    const item = 
      { id: maxId + 1,
        name: contactName, 
        email: contactEmail}
        setContacts([...contacts,item])
  }
  const deleteContact = (id) => {
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