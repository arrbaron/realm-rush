using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour {
  [SerializeField] Transform weapon;
  [SerializeField] ParticleSystem projectileParticles;
  [SerializeField] float range = 15f;
  Transform target; // TODO: remove serialization

  void Update() {
    FindClosestTarget();
    AimWeapon();
  }

  void FindClosestTarget() {
    Enemy[] enemies = FindObjectsOfType<Enemy>();
    Transform closestTarget = null;
    float maxDistance = Mathf.Infinity;

    foreach (Enemy enemy in enemies) {
      float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

      if (targetDistance < maxDistance) {
        closestTarget = enemy.transform;
        maxDistance = targetDistance;
      }
    }

    target = closestTarget;
  }

  void AimWeapon() {
    float targetDistance = Vector3.Distance(transform.position, target.position);
    bool inRange = targetDistance <= range;

    if (inRange) {
      weapon.LookAt(target);
    }

    Attack(inRange);
  }

  void Attack(bool isActive) {
    var particles = projectileParticles.GetComponent<ParticleSystem>();
    var emission = particles.emission;
    emission.enabled = isActive;
  }

}