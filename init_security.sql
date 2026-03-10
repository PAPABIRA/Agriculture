-- Script d'initialisation pour la sécurité
-- A exécuter dans MySQL

USE bdsenagriculture;

-- S'assurer que la table admins existe (si non créée par EF)
CREATE TABLE IF NOT EXISTS admins (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nom_prenom VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    login VARCHAR(50) NOT NULL UNIQUE,
    mot_de_passe VARCHAR(256) NOT NULL,
    role VARCHAR(50) DEFAULT 'Admin',
    est_actif BOOLEAN DEFAULT TRUE
);

-- Ajouter l'utilisateur admin par défaut (si n'existe pas déjà)
INSERT IGNORE INTO admins (
    nom_prenom,
    login,
    mot_de_passe,
    role,
    est_actif
)
VALUES (
        'Administrateur',
        'admin',
        '1234',
        'Admin',
        1
    );