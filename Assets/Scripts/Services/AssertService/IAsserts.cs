using UnityEngine;

namespace Services.AssertService
{
    public interface IAsserts
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}