using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MouseClick
{
    /// <summary>
    /// 平滑预测类，设置值和取值分离
    /// </summary>
    class SmoothValueHelper
    {
        private float mHz = 100f;
        private DateTime mValueTime = DateTime.Now;
        private float[] lastMValue;
        private float[] increaseSpeed;
        private float[] mSoomthValue;
        private System.Timers.Timer timer;
        private bool isTriggerEnabled = false;
        private int mDim = 3;

        private Stopwatch stopwatch;

        private long lastPostTime;

        public event EventHandler<float[]> SmoothValueRefreshed;
        public SmoothValueHelper(float freshHz, int dim)
        {
            //新建类的时候就开始定时器
            this.mDim = dim;
            this.mHz = freshHz;
            lastMValue = new float[mDim];
            increaseSpeed = new float[mDim];
            mSoomthValue = new float[mDim];
            //确保初始化的值为0(虽然不确定是否必要)
            for (int i = 0; i < mDim; i++)
            {
                lastMValue[i] = 0f;
                increaseSpeed[i] = 0f;
                mSoomthValue[i] = 0f;
            }

            initTimer();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            lastPostTime = stopwatch.ElapsedMilliseconds;



        }
        Task looptask;
        private void initTimer()
        {
            int interval = (int)(1000f / mHz);
            //在线程中循环
            looptask = new Task(() =>
            {
                while (true)
                {

                    try
                    {
                        //每次到时间就执行维护值的计算
                        mSoomthValue = getSmoothValue();

                        //添加行
                        if(isTriggerEnabled)
                        callOnValueRefresh(mSoomthValue);
                        //添加行

                        ////如果需要触发事件则调用触发
                        //if (isTriggerEnabled)
                        //{
                        //    var task = new Task(() =>
                        //    {

                        //        callOnValueRefresh(mSoomthValue);

                        //    });
                        //    task.Start();
                        //}
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    Thread.Sleep(interval);
                }
                
            });
            looptask.Start();


            //timer = new System.Timers.Timer();
            //int interval = (int)(1000f / mHz);
            //interval = interval <= 0 ? 1 : interval;//限定最小延时
            //timer.AutoReset = true;//一直执行
            ////设置是否执行System.Timers.Timer.Elapsed事件
            //timer.Enabled = true;
            ////绑定Elapsed事件
            //timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerUp);
        }
        /// <summary>
        /// 开始触发回调事件，定时输出 维护值
        /// </summary>
        public void startTrigger()
        {
            isTriggerEnabled = true;
        }
        private float[] valuesMulNum(float[] a, float num)
        {
            float[] result = new float[mDim];
            for (int i = 0; i < mDim; i++)
            {
                result[i] = a[i] * num;
            }
            return result;
        }
        private float[] valuesDivNum(float[] a, float num)
        {
            float[] result = new float[mDim];
            for (int i = 0; i < mDim; i++)
            {
                result[i] = a[i] / num;
            }
            return result;
        }
        private float[] valuesSub(float[] a, float[] b)
        {
            float[] result = new float[mDim];
            for (int i = 0; i < mDim; i++)
            {
                result[i] = a[i] - b[i];
            }
            return result;
        }
        private float[] valuesAdd(float[] a, float[] b)
        {
            float[] result = new float[mDim];
            for (int i = 0; i < mDim; i++)
            {
                result[i] = a[i] + b[i];
            }
            return result;
        }

        public void stopTrigger()
        {
            isTriggerEnabled = false;
        }

        /// <summary>
        /// 新增实际值
        /// </summary>
        /// <param name="value"></param>
        public void postValue(float[] values)
        {
            //当有最新数据更新立刻更新 维护值
            mSoomthValue = values;
            //DateTime thisTime = DateTime.Now;
            var currentTime = stopwatch.ElapsedMilliseconds;
            var interval = currentTime - lastPostTime;
            float[] dif = valuesSub(values, lastMValue);
            lastMValue = values;
            lastPostTime = currentTime;
            if (interval > 0)
                increaseSpeed = valuesDivNum(dif, interval);
            else
            {
                increaseSpeed = new float[mDim];//初值为0
            }
        }


        /// <summary>
        /// 获取维护值
        /// </summary>
        /// <returns>维护值</returns>
        public float[] getSmoothValue()
        {
            var currentTime = stopwatch.ElapsedMilliseconds;
            var interval = currentTime - lastPostTime;
            mSoomthValue = valuesAdd(valuesMulNum(increaseSpeed, interval), lastMValue);
            //mSoomthValue = interval * increaseSpeed + lastMValue;
            return mSoomthValue;
        }

        public float[] getNotSmoothValue()
        {
            return lastMValue;
        }



        /// <summary>
        /// 当调用startTrigger方法后系统会定时调用本方法，注意是在子线程中
        /// </summary>
        public void callOnValueRefresh(float[] smoothValues)
        {
            SmoothValueRefreshed?.Invoke(this, smoothValues);
        }

    }
}
