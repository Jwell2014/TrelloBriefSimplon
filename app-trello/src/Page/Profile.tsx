import React from 'react';
import CardProfile from '../Component/CardProfile';

interface IProfileProps {
    utilisateur: {
        idutilisateur: number;
        nom: string;
        prenom: string;
        photo: string;
    }[]
}

function Profile({ utilisateur }: IProfileProps) {

    return (
        <div className="card-container" >
            <CardProfile utilisateur={utilisateur} />
        </div>
    );
};

export default Profile;