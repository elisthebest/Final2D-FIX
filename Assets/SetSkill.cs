using UltimateCC;
using UnityEngine;

public class SetSkill : MonoBehaviour
{
    [Tooltip("AddSkill agrega una nueva habilidad de las ya existentes.\n" +
    "DoSkillSet activa o desactiva habilidades a gusto del desarrollador.")]
    [SerializeField] private SkillType skillsBehaviour = SkillType.DoSkillSet;

    public bool OnJump = false;
    public bool OnWalk = true;
    public bool OnDash = false;
    public bool OnCrouch = false;
    public bool OnWallGrab = false;
    public bool OnWallClimb = false;

    [Header("Feedback")]
    public AudioClip unlockSFX;

    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Collider2D triggerCollider;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        triggerCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerInputManager inputManager))
        {
            // Activar o agregar habilidades
            if (skillsBehaviour == SkillType.AddSkill)
            {
                inputManager.OnJumpEnable = this.OnJump || inputManager.OnJumpEnable;
                inputManager.OnWalkEnable = this.OnWalk || inputManager.OnWalkEnable;
                inputManager.OnDashEnable = this.OnDash || inputManager.OnDashEnable;
                inputManager.OnCrouchEnable = this.OnCrouch || inputManager.OnCrouchEnable;
                inputManager.OnWallGrabEnable = this.OnWallGrab || inputManager.OnWallGrabEnable;
                inputManager.OnWallClimbEnable = this.OnWallClimb || inputManager.OnWallClimbEnable;
            }
            else if (skillsBehaviour == SkillType.DoSkillSet)
            {
                inputManager.OnJumpEnable = this.OnJump;
                inputManager.OnWalkEnable = this.OnWalk;
                inputManager.OnDashEnable = this.OnDash;
                inputManager.OnCrouchEnable = this.OnCrouch;
                inputManager.OnWallGrabEnable = this.OnWallGrab;
                inputManager.OnWallClimbEnable = this.OnWallClimb;
            }

            // Ocultar visualmente y desactivar colisión
            if (spriteRenderer != null) spriteRenderer.enabled = false;
            if (triggerCollider != null) triggerCollider.enabled = false;

            // Reproducir el sonido usando un objeto separado
            PlaySoundAndDestroy();
        }
    }

    private void PlaySoundAndDestroy()
    {
        if (unlockSFX != null)
        {
            GameObject sfxPlayer = new GameObject("SkillUnlockSFX");
            AudioSource newSource = sfxPlayer.AddComponent<AudioSource>();
            newSource.clip = unlockSFX;
            newSource.Play();

            // Destruir el objeto temporal después de que termine el sonido
            Destroy(sfxPlayer, unlockSFX.length);
        }

        // Finalmente destruir este objeto (sin esperar si no hay sonido)
        Destroy(gameObject);
    }

    enum SkillType
    {
        AddSkill,
        DoSkillSet
    }
}
