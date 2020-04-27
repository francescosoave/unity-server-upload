using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class DataUploader: MonoBehaviour
{
    public enum UploadStatus
    {
        notStarted,
        started,
        successful,
        error,
        completed
    }
    public UploadStatus uploadStatus;

    public void Start()
    {
        uploadStatus = UploadStatus.notStarted;
    }

    public void UploadFile()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        uploadStatus = UploadStatus.started;

        string path = Application.dataPath + "/data_" + StaticData.GetDeviceId() + ".csv";
        WWWForm form = new WWWForm();
        UnityWebRequest dataFile = UnityWebRequest.Get(path);
        yield return dataFile.SendWebRequest();
        form.AddBinaryData("dataFile", dataFile.downloadHandler.data, Path.GetFileName(path));
        UnityWebRequest req = UnityWebRequest.Post("yourserverpath/getFile.php", form);
        yield return req.SendWebRequest();

        uploadStatus = UploadStatus.completed;

        Debug.Log("SERVER: " + req.downloadHandler.text); // server response

        if (req.isHttpError || req.isNetworkError || !(req.downloadHandler.text.Contains("FILE OK")))
            uploadStatus = UploadStatus.error;
        else
            uploadStatus = UploadStatus.successful;

        yield break;
    }
}
