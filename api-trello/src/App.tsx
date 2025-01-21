import React, { useEffect, useState } from 'react';
import './App.css';
import { PrimeReactProvider, PrimeReactContext } from 'primereact/api';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navigation from './Component/Navigation';
import Login from './Page/Login';
import Home from './Page/Home';
import Profile from './Component/CardProfile';
import axios from 'axios';
import Projet from './Page/Projet';


function App() {

  const [connected, setConnected] = useState(true);
  const [utilisateur, setUtilisateur] = useState<Array<{ idutilisateur: number, nom: string; prenom: string; motDePasse: string; description: string; photo: string; poste: string }>>([]);
  const [projet, setProjet] = useState<Array<{ idprojet: number, nomProjet: string, Idresponsable: number; }>>([]);

  const [loading, setLoading] = useState(true);


  useEffect(() => {
    axios.get('https://localhost:7203/api/Utilisateur')
      .then(response => {
        setUtilisateur(response.data);
        setLoading(false);
      })
      .catch(error => {
        console.error('Erreur lors de la récupération des données : ', error);
        setLoading(false);
      });
  }, []);

  useEffect(() => {
    axios.get('https://localhost:7203/api/projet')
      .then(response => {
        setProjet(response.data);
        setLoading(false);
        console.log(response.data)
      })
      .catch(error => {
        console.error('Erreur lors de la récupération des données : ', error);
        setLoading(false);
      });
  }, []);

  const findNomResponsable = (Idresponsable: number | null): string => {
    const responsable = utilisateur.find(user => user.idutilisateur === Idresponsable);
    return responsable ? `${responsable.nom} ${responsable.prenom}` : 'Inconnu';
  };


  return (
    <div className="App">
      <PrimeReactProvider>
        {!connected ?
          <Router>
            <Routes>
              <Route path="/" element={<Login connected={connected} setConnected={setConnected} />} />
            </Routes>
          </Router>
          :
          <Router>
            <Navigation setConnected={setConnected} />
            <Routes>
              <Route path="/" element={<Home utilisateur={utilisateur} projet={projet} findNomResponsable={findNomResponsable} />} />
              <Route path="/projet/:id" element={<Projet findNomResponsable={findNomResponsable} />} />
              <Route path="/profile" element={<Profile utilisateur={utilisateur} />} />
            </Routes>
          </Router>
        }
      </PrimeReactProvider>
    </div>
  );
}

export default App;
