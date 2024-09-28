import TableContact from "./layout/TableContact/TableContact";
import React,{useState,useEffect} from "react";
import FormContact from "./layout/Formcontact/FormContact";
import axios from 'axios';
import {Routes,Route, useLocation} from "react-router-dom";
import ContactDetails from "./layout/ContactDetails/ContactDetails";

const baseApiUrl = process.env.REACT_APP_API_URL;

const App = () => {
  const [contacts,setContacts] = useState([]);

  useEffect(()=>{
    const url = `${baseApiUrl}/contacts`;
    axios.get(url).then( 
      res => setContacts(res.data)
    );
  },);

  const addContact = (contactName,contactEmail) => {
    const item = 
      { name: contactName, 
        email: contactEmail};

        axios.post(`${baseApiUrl}/contacts`,item).then(
          response => setContacts([...contacts,response.data])
        );
  }
  

  return (
    <div className="container mt-5">
      <Routes>
        <Route path="/" element={
          <div className="card" >
            <div className="card-header">
              <h1>Number of contacts</h1>
            </div>

            <div className="card-body">
              <TableContact
                contacts={contacts}
              />
              <FormContact 
              addContact={addContact}
              />

            </div>
          </div>
        } />
        <Route path="contact/:id" element={<ContactDetails/>}/>
      </Routes>
    </div>
  );
}
 
export default App;