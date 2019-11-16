using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login
{
    public string id;
    public string nama;
    public string kelas;
    public string username;
    public bool login;
}

//GET LOGIN
public class GetLogin
{
    public List<Login> getLogin;
}

[System.Serializable]
public class Materi
{
    public string id;
    public string id_guru;
    public string judul_materi;
    public string isi_materi;
    public string tgl_materi;
}

//GET MATERI
public class GetMateri
{
    public List<Materi> getMateri;
    public Materi[] arrayMateri;
}

[System.Serializable]
public class Soal
{
    public string idSoal;
    public string idJawaban;
    public string isi_soal;
    public string jawaban_1;
    public string jawaban_2;
    public string jawaban_3;
    public string jawaban_4;
    public string jawaban_benar;
    public string point;
}

[System.Serializable]
public class Latihan
{
    public string idLatihan;
    public string nama_latihan;
    public List<Soal> getSoal;
    public Soal[] arraySoal;
}

[System.Serializable]
public class GetLatihan
{
    public List<Latihan> getLatihan;
    public Latihan[] arrayLatihan;
}



