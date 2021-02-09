using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicsSceneLoader : MonoBehaviour
{
    public string physicsSceneName;
    public float physicsSceneTimeScale = 1;
    private PhysicsScene physicsScene;

    private void Start()
    {
        LoadSceneParameters param = new LoadSceneParameters(LoadSceneMode.Additive, LocalPhysicsMode.Physics3D);
        Scene scene = SceneManager.LoadScene(physicsSceneName, param);
        physicsScene = scene.GetPhysicsScene();
    }

    private void FixedUpdate()
    {
        if(physicsScene != null)
        {
            physicsScene.Simulate(Time.fixedDeltaTime * physicsSceneTimeScale);
        }
    }

}
