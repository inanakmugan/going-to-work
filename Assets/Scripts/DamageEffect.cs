using System.Collections;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
     public SkinnedMeshRenderer playerRenderer;
    public Color flashColor = Color.red; // Color to flash
    public float flashDuration = 0.1f; // Duration of each flash
    private Material[] originalMaterials;
    private bool isFlashing = false;

    void Start()
    {
        // Store the original materials
        originalMaterials = playerRenderer.materials;
    }

    public void TakeDamage()
    {
        if (!isFlashing)
        {
            // Start the flash effect
            StartCoroutine(FlashRoutine());
        }
    }

    IEnumerator FlashRoutine()
    {
        isFlashing = true;

        // Flash the player for a short duration
        Material[] flashMaterials = new Material[originalMaterials.Length];
        for (int i = 0; i < flashMaterials.Length; i++)
        {
            flashMaterials[i] = new Material(originalMaterials[i]);
            flashMaterials[i].color = flashColor;
        }

        playerRenderer.materials = flashMaterials;
        yield return new WaitForSeconds(flashDuration);
        playerRenderer.materials = originalMaterials;

        isFlashing = false;
    }
}
