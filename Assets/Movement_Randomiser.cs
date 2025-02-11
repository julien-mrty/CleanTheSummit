using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Randomiser : MonoBehaviour
{
    // Définition des limites de déplacement
    [SerializeField]
    private Vector3 min;
    [SerializeField]
    private Vector3 max;
    // Définition de la plage de rotation sur y
    [SerializeField]
    private Vector2 yRotationRange;
    // Définition de la vitesse de déplacement
    [SerializeField]
    [Range(0.01f, 0.1f)]
    private float lerpSpeed = 0.05f;

    // Variable privée de stockage de la nouvelle rotation et de la nouvelle position
    [SerializeField]
    private Vector3 _positionCible;

    private Quaternion _newRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Initialisation des positions et rotations actuelles comme points de départ
        //_positionCible = new Vector3(max.x, max.y, max.z);
        //Debug.Log(_positionCible);
        _newRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // newPosition est le déplacement.
        //if(transform.position.y < max.y || transform.position.y > min.y)
        //{
        //    _positionCible.y = 0;
        //    Debug.Log("Position y set to 0 : "+transform.position);
        //}
        //if (transform.position.x < max.x || transform.position.x > min.x)
        //{
        //    _positionCible.x = 0;
        //    Debug.Log("Position x set to 0 : "+ transform.position);
        //}
        //if (transform.position.z < max.z || transform.position.z > min.z)
        //{
        //    _positionCible.z = 0;
        //    Debug.Log("Position z set to 0 : "+transform.position);
        //}
        //Debug.Log(transform.position);
        if (Vector3.Distance(transform.position, _positionCible) >= 0.1f)
        {
            // Déplacement progressif vers la nouvelle position avec un effet de lissage (lerp)
            transform.position = Vector3.Lerp(transform.position, _positionCible, Time.deltaTime * lerpSpeed);
            // Rotation progressive vers la nouvelle rotation cible
            transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * lerpSpeed);
            //Debug.Log(Vector3.Distance(transform.position, _positionCible));
        }




        // Vérifie si l'objet est proche de sa cible (seuil de 0.1 pour éviter les petites oscillations)
        //if (Vector3.Distance(transform.position, _positionCible) < 0.1f)
        //{

        //    // Génère une nouvelle position et rotation une fois la destination atteinte
        //    GetNewPosition();
        //}
    }

    void GetNewPosition()
    {
        System.Random rnd = new System.Random();

        // Génère une position aléatoire dans les limites définies (x et y)
        var xPos = UnityEngine.Random.Range(min.x, max.x);//(float)rnd.NextDouble()*(max.x-min.x) + min.x;
        var yPos = UnityEngine.Random.Range(min.y, max.y);//(float)rnd.NextDouble() * (max.y - min.y) + min.y;
        var zPos = UnityEngine.Random.Range(min.z, max.z);//(float)rnd.NextDouble() * (max.z - min.z) + min.z;

        // Génère une rotation aléatoire sur l’axe Y
        // Définit la nouvelle rotation aléatoire sur l’axe Y
        _newRotation = Quaternion.Euler(0, UnityEngine.Random.Range(yRotationRange.x, yRotationRange.y), 0);
        // Définit la nouvelle position tout en gardant la hauteur actuelle
        _positionCible = new Vector3(xPos, yPos, zPos);

    }
}

