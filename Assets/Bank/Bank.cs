using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour {
  [SerializeField] int startingBalance = 150;
  [SerializeField] TextMeshProUGUI displayBalance;

  [SerializeField] int currentBalance;
  public int CurrentBalance { get { return currentBalance; } }

  void Start() {
    currentBalance = startingBalance;
    UpdateDisplay();
  }

  public void Deposit(int amount) {
    currentBalance += Mathf.Abs(amount);
    UpdateDisplay();
  }

  public void Withdraw(int amount) {
    currentBalance -= Mathf.Abs(amount);
    UpdateDisplay();

    if (currentBalance < 0) {
      // Lose game
      ReloadScene();
    }
  }

  void UpdateDisplay() {
    displayBalance.text = "Gold: " + currentBalance;
  }

  void ReloadScene() {
    Scene currentScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(currentScene.buildIndex);
  }
}