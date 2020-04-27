using UnityEngine;
using UnityEngine.SceneManagement;

namespace Data_Upload
{
    public class Controller : MonoBehaviour
    {
        public InputManager button;
        public DataUploader dataUploader;
        private bool flag;
        private bool lockUpdate;

        private void Start()
        {
            // write results to file
            DataWriter.Initialize();
            DataWriter.WriteFile(StaticData.GetData());
            flag = false;
            lockUpdate = true;
        }

        void FixedUpdate()
        {
            if (flag && lockUpdate) // prevent running more than once
            {
                lockUpdate = flag = false;
                dataUploader.UploadFile();
            }
        }

        void Update()
        {
            if (button.IsPressed()) flag = true; //start upload when user presses button

            if (dataUploader.uploadStatus == DataUploader.UploadStatus.successful)
                SceneManager.LoadScene("NextScene");
            else if (dataUploader.uploadStatus == DataUploader.UploadStatus.error)
                SceneManager.LoadScene("ErrorScene");
        }
    }
}
