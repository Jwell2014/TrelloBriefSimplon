// Projet.js
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import CardTache from '../Component/CardTache';
import StatutTache from '../Component/StatutTache';

interface IProjetProps {
    findNomResponsable: (Idresponsable: number | null) => string
}
export interface IStatut {
    idstatutTache: number,
    libelleStatut: string
}

interface IStatutTache {
    idstatutTache: number,
    libelleStatut: string
}

interface IAction {
    description: string;
    estTerminee: boolean;
    idaction: number;
    idtache: number;
}

export interface ITache {
    idtache: number;
    titre: string;
    description: string;
    dateLimite: string;
    idresponsable: number;
    idstatutTache: number;
    actions: IAction[];
    idstatutTacheNavigation: IStatutTache[];
}

export interface IProjetDetails {
    idprojet: number;
    nomProjet: string;
    idresponsable: number;
    dateDebut: string;
    dateFinPrevue: string;
    detailsDuProjet: string;
    taches: ITache[];
}
const Projet = ({ findNomResponsable }: IProjetProps) => {
    const { id } = useParams();
    const [loading, setLoading] = useState(true);

    // Utilisation
    const [projetDetails, setProjetDetails] = useState<IProjetDetails | null>(null);
    const [statuts, setStatuts] = useState<IStatut[] | null>([]);



    console.log('projetDetails?.idprojet', projetDetails?.idprojet)
    console.log("action", projetDetails?.taches)

    useEffect(() => {
        axios.get(`https://localhost:7203/api/projet/${id}`)
            .then(response => {
                setProjetDetails(response.data);
                setLoading(false);
                console.log("response.date", response.data)
                console.log('p', projetDetails)
            })
            .catch(error => {
                console.error('Erreur lors de la récupération des données : ', error);
                setLoading(false);
            });
    }, [id]);

    useEffect(() => {
        axios.get(`https://localhost:7203/api/StatutTache`)
            .then(response => {
                setStatuts(response.data);
                setLoading(false);
                console.log("response.date", response.data)
                console.log('p', projetDetails)
            })
            .catch(error => {
                console.error('Erreur lors de la récupération des données : ', error);
                setLoading(false);
            });
    }, []);

    if (!projetDetails) {
        return <div>Loading...</div>;
    }



    return (
        <div>
            <h2>{projetDetails.nomProjet}</h2>
            <p>Début : {projetDetails.dateDebut}</p>
            <p>Fin prévue : {projetDetails.dateFinPrevue}</p>
            <p>Détails du projet : {projetDetails.detailsDuProjet}</p>
            <div>
                <StatutTache statuts={statuts} projetDetails={projetDetails} findNomResponsable={findNomResponsable} />
                {/* <CardTache projetDetails={projetDetails} findNomResponsable={findNomResponsable} /> */}
            </div>

        </div>

    );
};
export default Projet;
