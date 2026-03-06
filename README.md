Mountainside - https://polyhaven.com/a/mountainside

Rocky terrain 2- https://polyhaven.com/a/rocky_terrain_02

Stone pit fire - https://polyhaven.com/a/stone_fire_pit

Boat- https://assetstore.unity.com/packages/3d/vehicles/sea/old-rowboat-31917

Island - https://assetstore.unity.com/packages/3d/environments/landscapes/free-island-collection-104753

Coast Land rocks- https://polyhaven.com/a/coast_land_rocks_04

Rocking chair - https://polyhaven.com/a/Rockingchair_01

Bench- https://polyhaven.com/a/wooden_picnic_table

ceiling fan- https://assetstore.unity.com/search#q=free%20asset%20ceiling%20fan

Bedroom- https://assetstore.unity.com/packages/3d/props/furniture/bedroom-set-interior-264498

TV- https://assetstore.unity.com/packages/3d/props/electronics/tv-led-30-336056

Couch- https://assetstore.unity.com/packages/3d/props/furniture/chair-and-sofa-set-263004

Boats- https://assetstore.unity.com/packages/3d/vehicles/sea/boats-polypack-189866

People - https://assetstore.unity.com/packages/3d/characters/city-people-free-samples-260446

Pier- https://assetstore.unity.com/packages/3d/props/exterior/low-poly-bridges-pack-1-3-lods-137690

Desk- https://assetstore.unity.com/packages/3d/props/furniture/desk-table-96582

Floor- https://polyhaven.com/a/slab_tiles

Code for Boats: using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatController : MonoBehaviour
{
    [Header("Boat Settings")]
    public float moveSpeed = 20f;
    public float turnSpeed = 50f;
    
    [Header("Water Resistance")]
    public float waterDrag = 2f;
    public float waterAngularDrag = 2f;

    private Rigidbody rb;
    private float moveInput;
    private float turnInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Simulating water resistance so the boat doesn't glide forever
        rb.drag = waterDrag;
        rb.angularDrag = waterAngularDrag;
        
        // Keep the boat from tipping over easily
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // 1. Gather Input during Update (W/S or Up/Down for forward/back, A/D or Left/Right for steering)
        moveInput = Input.GetAxis("Vertical"); 
        turnInput = Input.GetAxis("Horizontal"); 
    }

    void FixedUpdate()
    {
        // 2. Apply physics during FixedUpdate
        MoveBoat();
        TurnBoat();
    }

    private void MoveBoat()
    {
        // Push the boat in the direction it is currently facing
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            rb.AddForce(transform.forward * moveInput * moveSpeed, ForceMode.Acceleration);
        }
    }

    private void TurnBoat()
    {
        // Rotate the boat around its Y (Up) axis
        if (Mathf.Abs(turnInput) > 0.1f)
        {
            // Optional realism: You can multiply currentTurn by moveInput so the boat only turns when moving!
            float currentTurn = turnInput * turnSpeed * Time.fixedDeltaTime;
            
            // Create a rotation quaternion and apply it to the Rigidbody
            Quaternion turnRotation = Quaternion.Euler(0f, currentTurn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}
