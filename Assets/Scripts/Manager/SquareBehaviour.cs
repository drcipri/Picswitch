using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehaviour : MonoBehaviour
{
    //Serialize
    [Header("Parameters")]
    [SerializeField] private float squareSpeed = 0.1f;
    [Header("Components")]
    [SerializeField] private Vector3 originalLocation;
    [SerializeField] private SoundManagerSO soundManagerSO;
     


    //Non Serialize
    private PuzzleProgress puzzleProgress;
    private SpriteRenderer spriteRenderer;
    private LocationManager locationManager;
    private BoxCollider2D boxCollider2d;
    private GameObject squareLed;

    private int layerSquare = 6;
    private int layerIgnoreRayCast = 2;
    private bool stopLinecast = false;
   
    //movement
    private Vector3 newPosition;
    private Vector3 oldPosition;
    private GameObject selectedSquare;
    private bool moveSquares = false;
    
    
    //place
    private bool checkPlace = false;
    private bool inPlace = false;


    private void Awake()
    {
        //Sprite renderer need to be called in awake because matrice generate in awake and set sprite in awake
        spriteRenderer = GetComponent<SpriteRenderer>();
        locationManager = GameObject.FindGameObjectWithTag("LocationManager").GetComponent<LocationManager>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        puzzleProgress = GameObject.FindGameObjectWithTag("PuzzleProgress").GetComponent<PuzzleProgress>();
        squareLed = gameObject.transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        StartCoroutine(CheckSquareLocation());
        StartCoroutine(PuzzleSolvedLedEffect());

    }


    private void Update()
    {
        MoveSquares();
        LockSquare();
        TargetSquare();
    }

    private void TargetSquare()
    {
        if (Input.touchCount > 0 && locationManager.GetSquareLocked() == gameObject && puzzleProgress.GetStopGame() == false)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Moved)
            {
                if (stopLinecast == false)
                {
                    RaycastHit2D hit = Physics2D.Linecast(transform.position, touchPos);

                    if (hit.collider != null)
                    {
                        if (hit.collider.TryGetComponent(out SquareBehaviour squareBehaviour))
                        {
                            selectedSquare = squareBehaviour.gameObject;
                            newPosition = squareBehaviour.transform.position;
                            oldPosition = transform.position;
                            moveSquares = true;
                            stopLinecast = true;
                        }
                    }
                }
                

            }
            if (touch.phase == TouchPhase.Ended)
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                locationManager.SetSquareLockedNull();
                gameObject.layer = layerSquare;
                stopLinecast = false;
                
            }

        }
    }

    private void LockSquare()
    {
        if (locationManager.GetSquareLocked() == null && puzzleProgress.GetStopGame() == false )
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                if (boxCollider2d.bounds.Contains(touchPos))
                {
                    locationManager.SetSquareLocked(gameObject);
                    gameObject.layer = layerIgnoreRayCast;
                    spriteRenderer.color = new Color(1f,1f,1f,0.5f);
                }
            }
        }
    }

    private void MoveSquares()
    {
        if(moveSquares == true)
        {
            float deltaMove = squareSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, newPosition, deltaMove);
            selectedSquare.transform.position = Vector2.MoveTowards(selectedSquare.transform.position, oldPosition, deltaMove);
            
            if (transform.position == newPosition && selectedSquare.transform.position == oldPosition)
            {
                AudioSource.PlayClipAtPoint(soundManagerSO.SquareMoveSound(), Camera.main.transform.position, soundManagerSO.GetEffectsVolume());
                moveSquares = false;
                SetCheckPlace(true);
                selectedSquare.GetComponent<SquareBehaviour>().SetCheckPlace(true);
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                if (puzzleProgress.GetMoveGame() == true)
                {
                    puzzleProgress.SetMoves();
                }
            }

        }
    }

    public void StoreOriginalLocation(Vector3 position)
    {
        originalLocation = position;
    }

    IEnumerator CheckSquareLocation()
    {
        while(true)
        {
            if(transform.position == originalLocation)
            {
                StartCoroutine(SquareLed());
                locationManager.SetSquareInPlace(true);
                SetInPlace(true);
            }
            else if(inPlace == true && transform.position != originalLocation)
            {
                locationManager.SetSquareInPlace(false);
                SetInPlace(false);
            }
            SetCheckPlace(false);
            yield return new WaitUntil(() => checkPlace == true);
        }
    }

    IEnumerator SquareLed()
    {

        squareLed.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        squareLed.SetActive(false);


    }
    IEnumerator PuzzleSolvedLedEffect()
    {
        bool effect = true;
        while(effect)
        {
            yield return new WaitUntil(() => puzzleProgress.GetProgress() >= 100f);
            StartCoroutine(SquareLed());
            AudioSource.PlayClipAtPoint(soundManagerSO.LedZap(), Camera.main.transform.position, soundManagerSO.GetLoudSoundsVolume());
            effect = false;
            
        }    
    }

    //check if square is in place and set in place
    public void SetCheckPlace(bool set)
    {
        checkPlace = set;
    }
    public void SetInPlace(bool set)
    {
        inPlace = set;
    }

    //add sprites
    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite; 
    }


  

    
}
