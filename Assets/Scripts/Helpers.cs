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


//GET SOAL
[System.Serializable]
public class soal
{
    public string idSoal;
    public string idJawaban;
    public string isi_soal;
    public string jawaban_1;
    public string jawaban_2;
    public string jawaban_3;
    public string jawaban_4;
    public string jawaban_benar;
    public int point;
}

//GET LATIHAN
[System.Serializable]
public class Latihan
{
    public string idLatihan;
    public string nama_latihan;
    public List<soal> soal = new List<soal>();
    public soal[] arraySoal;
}

//LIST GET LATIHAN
[System.Serializable]
public class GetLatihan
{
    public List<Latihan> getLatihan;
    public Latihan[] arrayLatihan;
}

//POST NILAI SIMULASI
[System.Serializable]
public class PostNilaiSimulasi
{
    public string id_murid;
    public string nama_simulasi;
    public string score_simulasi;
    
}

//GET NILAI SIMULASI
[System.Serializable]
public class NilaiSimulasi
{
    public string id;
    public string nama_simulasi;
    public int score_simulasi;
    public string tgl_simulasi;
}

[System.Serializable]
public class ListNilaiSimulasi
{
    public string id;
    public string nama_simulasi;
    public string score_simulasi;
    public string tgl_simulasi;
}


//GET NILAI SIMULASI
[System.Serializable]
public class GetListNilaiSimulasi
{
    public List<ListNilaiSimulasi> listNilaiSimulasi;
}

//GET NILAI SIMULASI
[System.Serializable]
public class GetNilaiSimulasi
{
    public List<NilaiSimulasi> nilaiSimulasi;
    public List<ListNilaiSimulasi> listNilaiSimulasi;
}

//GET JAWABAN LATIHAN
[System.Serializable]
public class JawabanLatihan
{
    public string idNilaiSoal;
    public string soal;
    public string jawaban;
    public string score;
}

//GET NILAI LATIHAN
[System.Serializable]
public class GetNilaiLatihan
{
    public string idLatihan;
    public string nama_latihan;
    public string total_score;
    public List<JawabanLatihan> jawaban;
}

//GET LIST NILAI LATIHAN
[System.Serializable]
public class GetListNilaiLatihan
{
    public List<GetNilaiLatihan> getNilaiLatihan;
    public GetNilaiLatihan[] getArrayNilaiLatihan;
}

[System.Serializable]
public class Leaderboard
{
    public string id;
    public string nama;
    public string nilai_akhir;
}

[System.Serializable]
public class GetLeaderboard
{
    public List<Leaderboard> getLeaderboard;
}








