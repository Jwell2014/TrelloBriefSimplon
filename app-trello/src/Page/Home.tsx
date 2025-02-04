import React from 'react';
import CardProjet from '../Component/CardProjet';
import CardUtilisateur from '../Component/CardUtilisateur';

interface IHomeProps {
    utilisateur: {
        idutilisateur: number, nom: string; prenom: string; motDePasse: string; description: string; photo: string; poste: string
    }[],
    projet: {
        idprojet: number;
        nomProjet: string;
        idresponsable: number;
    }[],
    findNomResponsable: (idresponsable: number | null) => string
}

function Home({ utilisateur, projet, findNomResponsable }: IHomeProps) {

    return (
        <div className="flex justify-content-around" >
            <CardUtilisateur utilisateur={utilisateur} />
            <CardProjet projet={projet} utilisateur={utilisateur} findNomResponsable={findNomResponsable} />
        </div>
    );
};

export default Home;