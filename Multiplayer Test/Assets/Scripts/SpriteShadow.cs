using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteShadow : MonoBehaviour
{
    public Vector2 offset = new Vector2(-0.2f, -0.2f);

    private SpriteRenderer spriteCaster;
    private SpriteRenderer spriteShadow;

    private Transform transCaster;
    private Transform transShadow;

    public Material shadowMaterial;
    public Color shadowColor;

    void Start()
    {
        transCaster = transform;
        transShadow = new GameObject().transform;
        transShadow.parent = transCaster;
        transShadow.gameObject.name = "Shadow";
        transShadow.localRotation = Quaternion.identity;

        spriteCaster = GetComponent<SpriteRenderer>();
        spriteShadow = transShadow.gameObject.AddComponent<SpriteRenderer>();

        spriteShadow.material = shadowMaterial;
        spriteShadow.color = shadowColor;
        spriteShadow.sortingLayerName = spriteCaster.sortingLayerName;
        spriteShadow.sortingOrder = spriteCaster.sortingOrder - 1;
    }

    void LateUpdate()
    {
        transShadow.position = transform.parent.transform.position + (Vector3)offset;
        spriteShadow.sprite = spriteCaster.sprite;
    }
}
