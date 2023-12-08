

public interface IController
{
    /// <summary>
    /// Initialze the controller
    /// </summary>
    void Initialize();

    /// <summary>
    /// Register all your controller releated Events at one place
    /// </summary>
    void RegisterListener();

    /// <summary>
    /// UnRegister all your controller related Events at one place
    /// </summary>
    void UnRegisterListener();

    /// <summary>
    /// Update will called once per frame
    /// </summary>
    void Update();
}